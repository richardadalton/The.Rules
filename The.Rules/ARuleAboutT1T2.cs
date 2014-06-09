using System;
using The.Rules.Operators.T1T2;

namespace The.Rules
{
    public class ARuleAbout<T1,T2>
    {
        private readonly Func<T1, T2, bool> rule;

        protected ARuleAbout() { }

        public string Text { get; private set; }

        public ARuleAbout(Func<T1, T2, bool> rule, string description)
        {
            this.rule = rule;
            Text = description;
        }

        public virtual bool IsTrueFor(T1 first, T2 second)
        {
            return rule.Invoke(first, second);
        }

        public virtual bool IsFalseFor(T1 first, T2 second)
        {
            return !IsTrueFor(first, second);
        }

        public static ARuleAbout<T1, T2> Where(Func<T1, T2, bool> rule, string description = "")
        {
            return new ARuleAbout<T1, T2>(rule, description);
        }

        public AndRule<T1, T2> And(ARuleAbout<T1, T2> otherRule)
        {
            return new AndRule<T1, T2>(this, otherRule);
        }

        public OrRule<T1, T2> Or(ARuleAbout<T1, T2> otherRule)
        {
            return new OrRule<T1, T2>(this, otherRule);
        }

        public XorRule<T1, T2> Xor(ARuleAbout<T1, T2> otherRule)
        {
            return new XorRule<T1, T2>(this, otherRule);
        }

        public ImpliesRule<T1, T2> Implies(ARuleAbout<T1, T2> otherRule)
        {
            return new ImpliesRule<T1, T2>(this, otherRule);
        }

        public PreventsRule<T1, T2> Prevents(ARuleAbout<T1, T2> otherRule)
        {
            return new PreventsRule<T1, T2>(this, otherRule);
        }

        public NotRule<T1, T2> Not()
        {
            return new NotRule<T1, T2>(this);
        }
    }
}
