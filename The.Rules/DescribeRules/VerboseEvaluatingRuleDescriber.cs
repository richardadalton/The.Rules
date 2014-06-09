using The.Rules.Operators.T;

namespace The.Rules.DescribeRules
{
    public class VerboseEvaluatingRuleDescriber<T> : AbstractRuleDescriber<T>
    {
        private readonly T evaluateWith;

        public VerboseEvaluatingRuleDescriber (T evaluateWith)
        {
            this.evaluateWith = evaluateWith;
        }
        
        protected override string DescribeRule(ARuleAbout<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("{0}[{1}]", rule.Text, result);
        }

        protected override string DescribeAndRule(AndRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("({0} AND {1})[{2}]", Describe(rule.Left), Describe(rule.Right), result);
        }

        protected override string DescribeOrRule(OrRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("({0} OR {1})[{2}]", Describe(rule.Left), Describe(rule.Right), result);
        }

        protected override string DescribeNotRule(NotRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("NOT ({0})[{1}]", Describe(rule.Rule), result);
        }

        protected override string DescribeXorRule(XorRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("({0} XOR {1})[{2}]", Describe(rule.Left), Describe(rule.Right), result);
        }

        protected override string DescribeImpliesRule(ImpliesRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("({0} IMPLIES {1})[{2}]", Describe(rule.Left), Describe(rule.Right), result);
        }

        protected override string DescribePreventsRule(PreventsRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            return string.Format("({0} PREVENTS {1})[{2}]", Describe(rule.Left), Describe(rule.Right), result);
        }

        private string DescribeResult(bool result)
        {
            return result.ToString().Substring(0, 1);
        }
    }
}
