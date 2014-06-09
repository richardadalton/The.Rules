using System;
using The.Rules.Operators.T;

namespace The.Rules
{
    public class ARuleAbout<T>
    {
        private readonly Func<T, bool> rule;

        protected ARuleAbout() {}

        public string Text { get;  private set; }

        public ARuleAbout(Func<T, bool> rule, string description)
        {
            this.rule = rule;
            Text = description;
        }

        public virtual bool IsTrueFor(T theObject)
        {
            return rule.Invoke(theObject);
        }

        public bool IsFalseFor(T theObject)
        {
            return !IsTrueFor(theObject);
        }

        public static ARuleAbout<T> Where(Func<T, bool> rule, string description = "")
        {
            return new ARuleAbout<T>(rule, description);
        }

        public AndRule<T> And(ARuleAbout<T> otherRule)
        {
            return new AndRule<T>(this, otherRule);
        }

        public OrRule<T> Or(ARuleAbout<T> otherRule)
        {
            return new OrRule<T>(this, otherRule);
        }

        public XorRule<T> Xor(ARuleAbout<T> otherRule)
        {
            return new XorRule<T>(this, otherRule);
        }

        public ImpliesRule<T> Implies(ARuleAbout<T> otherRule)
        {
            return new ImpliesRule<T>(this, otherRule);
        }

        public PreventsRule<T> Prevents(ARuleAbout<T> otherRule)
        {
            return new PreventsRule<T>(this, otherRule);
        }

        public NotRule<T> Not()
        {
            return new NotRule<T>(this);
        }
    }
}
