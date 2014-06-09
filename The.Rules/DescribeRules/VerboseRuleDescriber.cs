using The.Rules.Operators.T;

namespace The.Rules.DescribeRules
{
    public class VerboseRuleDescriber<T> : AbstractRuleDescriber<T>
    {
        protected override string DescribeRule(ARuleAbout<T> rule)
        {
            return rule.Text;
        }

        protected override string DescribeAndRule(AndRule<T> rule)
        {
            return string.Format("({0} AND {1})", Describe(rule.Left), Describe(rule.Right));
        }

        protected override string DescribeOrRule(OrRule<T> rule)
        {
            return string.Format("({0} OR {1})", Describe(rule.Left), Describe(rule.Right));
        }

        protected override string DescribeNotRule(NotRule<T> rule)
        {
            return string.Format("NOT {0}", Describe(rule.Rule));
        }

        protected override string DescribeXorRule(XorRule<T> rule)
        {
            return string.Format("({0} XOR {1})", Describe(rule.Left), Describe(rule.Right));
        }

        protected override string DescribeImpliesRule(ImpliesRule<T> rule)
        {
            return string.Format("({0} IMPLIES {1})", Describe(rule.Left), Describe(rule.Right));
        }

        protected override string DescribePreventsRule(PreventsRule<T> rule)
        {
            return string.Format("({0} PREVENTS {1})", Describe(rule.Left), Describe(rule.Right));
        }        
    }
}
