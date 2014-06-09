
namespace The.Rules.Operators.T1T2
{
    public class NotRule<T1, T2> : ARuleAbout<T1, T2>
    {
        public ARuleAbout<T1, T2> Rule { get; private set; }

        public NotRule(ARuleAbout<T1, T2> rule)
        {
            Rule = rule;
        }

        public override bool IsTrueFor(T1 theObject, T2 theOtherObject)
        {
            return Rule.IsFalseFor(theObject, theOtherObject);
        }
    }
}
