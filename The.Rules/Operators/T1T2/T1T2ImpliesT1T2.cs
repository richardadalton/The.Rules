﻿namespace The.Rules.Operators.T1T2
{
    public class ImpliesRule<T1, T2>: ARuleAbout<T1, T2>
    {
        public ARuleAbout<T1, T2> Left { get; private set; }
        public ARuleAbout<T1, T2> Right { get; private set; }

        public ImpliesRule(ARuleAbout<T1, T2> left, ARuleAbout<T1, T2> right)
        {
            Left = left;
            Right = right;
        }

        public override bool IsTrueFor(T1 first, T2 second)
        {
            return Left.IsFalseFor(first, second) || Right.IsTrueFor(first, second);
        }
    }
}
