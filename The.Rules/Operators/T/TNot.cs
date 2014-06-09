
namespace The.Rules.Operators.T
{
    public class NotRule<T> : ARuleAbout<T>
    {
        public ARuleAbout<T> Rule { get; private set; }

        public NotRule(ARuleAbout<T> rule)
        {
            Rule = rule;
        }

        public override bool IsTrueFor(T theObject)
        {
            return Rule.IsFalseFor(theObject);
        }
    }
}
