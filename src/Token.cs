namespace Axes
{
    class Token
    {
        public int line;
        public TokenType tokenType;
        public string lexeme;
        public string literal;
    }

    public enum TokenType
    {
        COMMAND, LITERAL
    }
}
