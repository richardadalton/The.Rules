using The.Rules.Operators.T;

namespace The.Rules.DescribeRules
{
    public abstract class AbstractRuleDescriber<T>
    {
        public string Describe(ARuleAbout<T> rule)
        {
            if (rule is AndRule<T>)
                return DescribeAndRule(rule as AndRule<T>);

            if (rule is OrRule<T>)
                return DescribeOrRule(rule as OrRule<T>);

            if (rule is NotRule<T>)
                return DescribeNotRule(rule as NotRule<T>);

            if (rule is XorRule<T>)
                return DescribeXorRule(rule as XorRule<T>);

            if (rule is ImpliesRule<T>)
                return DescribeImpliesRule(rule as ImpliesRule<T>);

            if (rule is PreventsRule<T>)
                return DescribePreventsRule(rule as PreventsRule<T>);

            return DescribeRule(rule);
        }

        protected abstract string DescribeRule(ARuleAbout<T> rule);
        protected abstract string DescribeAndRule(AndRule<T> rule);
        protected abstract string DescribeOrRule(OrRule<T> rule);
        protected abstract string DescribeNotRule(NotRule<T> rule);
        protected abstract string DescribeXorRule(XorRule<T> rule);
        protected abstract string DescribeImpliesRule(ImpliesRule<T> rule);
        protected abstract string DescribePreventsRule(PreventsRule<T> rule);
    }
}
