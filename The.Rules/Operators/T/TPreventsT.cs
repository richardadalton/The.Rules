namespace The.Rules.Operators.T
{
    public class PreventsRule<T> : ARuleAbout<T>
    {
        public ARuleAbout<T> Left { get; private set; }
        public ARuleAbout<T> Right { get; private set; }

        public PreventsRule(ARuleAbout<T> left, ARuleAbout<T> right)
        {
            Left = left;
            Right = right;
        }

        public override bool IsTrueFor(T theObject)
        {
            return !(Left.IsTrueFor(theObject) && Right.IsTrueFor(theObject));
        }
    }
}
