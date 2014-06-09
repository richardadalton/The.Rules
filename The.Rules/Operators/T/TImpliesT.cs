namespace The.Rules.Operators.T
{
    public class ImpliesRule<T> : ARuleAbout<T>
    {
        public ARuleAbout<T> Left { get; private set; }
        public ARuleAbout<T> Right { get; private set; }

        public ImpliesRule(ARuleAbout<T> left, ARuleAbout<T> right)
        {
            Left = left;
            Right = right;
        }

        public override bool IsTrueFor(T theObject)
        {
            return Left.IsFalseFor(theObject) || Right.IsTrueFor(theObject);
        }
    }
}
