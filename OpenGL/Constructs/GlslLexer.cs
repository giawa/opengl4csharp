using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace OpenGL
{
    public static class GlslLexer
    {
        #region Regex
        // super simple regex expression that should find most of the different GLSL tokens
        // note:  we only really care about syntax and words
        private static string pattern =
                    @"(?<word>([a-zA-Z_][a-zA-Z0-9_\$]*)|([\\][^\s]*))|" +
                    @"(?<number>([0-9]+\.?[0-9]*[Ee]-?[0-9]+))|" +
                    @"(?<operator>(\+|->?|\*|<=|%|>=|/|>{1,3}|<{1,3}|~|&{1,2}|\|{1,2}|\^|!={0,2}|={2,3}))|" +
                    "(?<string>\".*?\")|" +
                    @"(?<syntax>(;|#|=|\(|\)|,|@|\?|:|;|\[|\]|{|}))|" +
                    @"(?<other>.+?)";

        private static Regex regex = new Regex(pattern, RegexOptions);

        static readonly RegexOptions RegexOptions =
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant |
            RegexOptions.IgnoreCase |
            RegexOptions.IgnorePatternWhitespace |
            RegexOptions.Singleline;
        #endregion

        #region Keywords Dictionary
        // Load the basic GLSL 1.1 keywords into a dictionary.  We could expand this at a later date.
        private static string[] keywords = new string[] { "const", "uniform", "break", "continue", "do", "for", "while", "if", "else", "in", "out", "inout", "true", "false", "discard", "return", "struct", "attribute", "varying" };
        private static Dictionary<string, TokenType> keywordDictionary = new Dictionary<string, TokenType>();
        #endregion

        #region Token
        public enum TokenType
        {
            Keyword,        // glsl keywords
            Operator,       // assignment, math, etc
            String,         // a glsl string (surrounded by quotes)
            Number,         // a number
            Word,           // a variable name
            Syntax,         // glsl language construct (braces, parenthesis, etc)
            TODO,           // TODO comment
            Comment,        // A normal comment
            Unknown         // unknown token type
        }

        public class Token
        {
            /// <summary>
            /// The token type associated with this GLSL token.
            /// </summary>
            public TokenType TokenType { get; private set; }

            /// <summary>
            /// The line number that this token was read from.
            /// </summary>
            public int LineNumber { get; private set; }

            /// <summary>
            /// The text representation of this token.
            /// </summary>
            public string Text { get; private set; }

            /// <summary>
            /// The offset into the line of the file that this token was read from.
            /// </summary>
            public int Offset { get; private set; }

            public Token(string text, int lineNumber, int offset, TokenType type)
            {
                if (type == TokenType.Number)
                {
                    if (text.Contains("_")) text = text.Replace("_", "");
                    if (text.Contains("'s")) text = text.Substring(0, text.IndexOf('s')) + text.Substring(text.IndexOf('s') + 1);
                }

                this.Text = text;
                this.LineNumber = lineNumber;
                this.Offset = offset;
                this.TokenType = type;
            }

            public void SetText(string text)
            {
                this.Text = text;
            }

            public override string ToString()
            {
                return string.Format("Token \"{0}\" is of type {1}.", Text, TokenType);
            }
        }

        public static TokenType GetTokenType(Match m)
        {
            if (m.Groups["word"].Success)
            {
                if (keywordDictionary.ContainsKey(m.Value)) return TokenType.Keyword;
                else return TokenType.Word;
            }
            else if (m.Groups["number"].Success) return TokenType.Number;
            else if (m.Groups["operator"].Success) return TokenType.Operator;
            else if (m.Groups["string"].Success) return TokenType.String;
            else if (m.Groups["syntax"].Success) return TokenType.Syntax;
            else return TokenType.Unknown;
        }
        #endregion

        #region Line
        public class Line
        {
            /// <summary>
            /// The line number associated with this GLSL line.
            /// </summary>
            public int LineNumber { get; private set; }

            /// <summary>
            /// The text contents of this GLSL line.
            /// </summary>
            public string Text { get; private set; }

            /// <summary>
            /// True if this GLSL line is a comment.
            /// </summary>
            public bool Comment { get; private set; }

            public Line(string text, int lineNumber, bool comment = false)
            {
                this.Text = text;
                this.LineNumber = lineNumber;
                this.Comment = comment;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        #endregion

        #region Static Constructor
        /// <summary>
        /// Populates the keyword dictionary only once so that it can be recycled.
        /// </summary>
        static GlslLexer()
        {
            if (keywordDictionary.Count == 0)
                foreach (string keyword in keywords) keywordDictionary.Add(keyword, TokenType.Keyword);
        }
        #endregion

        #region GetTokens and GetLines
        /// <summary>
        /// Get a list of tokens that make up a single line of a GLSL program.
        /// </summary>
        /// <param name="line">The contents of the line of the GLSL program.</param>
        /// <param name="lineNumber">The line number associated with the line.</param>
        /// <param name="offset">An offset into the line number associated with the GLSL program.</param>
        /// <returns>A list of tokens that make up a single line of a GLSL program.</returns>
        public static List<Token> GetTokens(string line, int lineNumber = 0, int offset = 0)
        {
            List<Token> tokens = new List<Token>();
            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match m in matches)
            {
                if (m.Value == " " || m.Value == "\t") continue;
                tokens.Add(new Token(m.Value, lineNumber, offset + m.Index, GetTokenType(m)));
            }

            return tokens;
        }

        /// <summary>
        /// Get a list of tokens that make up a GLSL program that has already been broken into a list of lines.
        /// </summary>
        /// <param name="lines">A list of lines that make up the GLSL program.</param>
        /// <returns>A list of tokens that make up a GLSL program.</returns>
        public static List<Token> GetTokens(List<Line> lines)
        {
            List<Token> tokens = new List<Token>();
            List<Token> todos = new List<Token>();
            List<Token> comments = new List<Token>();

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Comment)
                {
                    if (lines[i].Text.ToUpper().Contains("TODO:"))
                    {
                        string line = lines[i].Text;
                        while (line.Contains("//"))
                        {
                            if (line.IndexOf("//") < line.ToUpper().IndexOf("TODO:")) line = line.Substring(line.IndexOf("//") + 2);
                            else break;
                        }
                        todos.Add(new Token(line.Trim(), lines[i].LineNumber, 0, TokenType.TODO));
                    }
                    else comments.Add(new Token(lines[i].Text, lines[i].LineNumber, 0, TokenType.Comment));
                }
                else tokens.AddRange(GetTokens(lines[i].Text, lines[i].LineNumber));
            }

            tokens.AddRange(todos); // add the todos to the end of the token list
            tokens.AddRange(comments);

            return tokens;
        }

        /// <summary>
        /// Get a list of tokens that make up a GLSL program.
        /// </summary>
        /// <param name="filename">The file that contains the GLSL program.</param>
        /// <returns>A list of tokens that make up the GLSL program.</returns>
        public static List<Token> GetTokens(string filename)
        {
            if (!File.Exists(filename)) return new List<Token>();
            Environment.CurrentDirectory = new FileInfo(filename).DirectoryName;
            return GetTokens(GetLines(filename));
        }

        /// <summary>
        /// Get a list of tokens that make up a GLSL program that is already loaded off the disk.
        /// </summary>
        /// <param name="fileContents">A string containing the GLSL program.</param>
        /// <returns>A list of tokens that make up the GLSL program.</returns>
        public static List<Token> GetTokensFromMemory(string fileContents)
        {
            return GetTokens(GetLinesFromMemory(fileContents));
        }

        /// <summary>
        /// Get a list of the lines that make up the GLSL program.
        /// </summary>
        /// <param name="filename">The file that contains the GLSL program.</param>
        /// <returns>A list of lines that make up the GLSL program.</returns>
        public static List<Line> GetLines(string filename)
        {
            using (StreamReader stream = new StreamReader(filename))
                return GetLinesFromMemory(stream.ReadToEnd(), filename);
        }

        /// <summary>
        /// Get a list of the lines that make up the GLSL program.
        /// </summary>
        /// <param name="fileContents">A string containing the GLSL program.</param>
        /// <param name="filename">An optional filename to associate with the provided GLSL program.</param>
        /// <returns>A list of lines that make up the GLSL program.</returns>
        public static List<Line> GetLinesFromMemory(string fileContents, string filename = "")
        {
            return GetLinesFromMemoryInternal(fileContents, filename);
        }

        private static List<Line> GetLinesFromMemoryInternal(string fileContents, string filename = "")
        {
            List<Line> lines = new List<Line>();
            int lineNumber = 0;

            using (StringReader stream = new StringReader(fileContents))
            {
                bool comment = false, remove = false;
                string temp = "";

                while ((temp = stream.ReadLine()) != null)
                {
                    lineNumber++;

                    // remove // comments first, they have priority
                    if (temp.Contains("//"))
                    {
                        int index = temp.IndexOf("//");

                        // watch out for *///
                        if (index > 0 && temp[index - 1] == '*')
                        {
                            string sub = temp.Substring(index + 1);
                            if (sub.Contains("//")) index = temp.IndexOf("//");
                            else index = -1;
                        }

                        if (index != -1)
                        {
                            if (!remove) lines.Add(new Line(temp.Substring(index + 2), lineNumber, true));
                            temp = temp.Substring(0, index);
                        }
                    }

                    // search for the end of a comment block if we're currently in one
                    if (comment)
                    {
                        if (temp.Contains("*/")) { temp = temp.Substring(temp.IndexOf("*/") + 2); comment = false; }
                        else continue;
                    }

                    // search for inline comment blocks
                    string line = temp;
                    while (line.Contains("/*"))
                    {
                        line = line.Substring(0, line.IndexOf("/*"));
                        comment = true;
                        if (temp.Contains("*/"))
                        {
                            temp = temp.Substring(temp.IndexOf("*/") + 2);
                            line += temp;
                            comment = false;
                        }
                    }

                    if (!remove)
                    {
                        if (line.Length > 0) lines.Add(new Line(line, lineNumber));
                    }
                }
            }

            return lines;
        }
        #endregion
    }
}
