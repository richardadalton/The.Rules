using The.Rules.DescribeRules;
using The.Rules.Operators;
using The.Rules.Operators.T;

namespace The.Rules.CustomDescriber
{
    public class SimplifiedEvaluatingRuleDescriber<T> : AbstractRuleDescriber<T>
    {
        private readonly T evaluateWith;

        public SimplifiedEvaluatingRuleDescriber(T evaluateWith)
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
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);
            
            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} AND[{2}] {1}", leftDescription, rightDescription, result);
        }

        protected override string DescribeOrRule(OrRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} OR[{2}] {1}", leftDescription, rightDescription, result);
        }

        protected override string DescribeNotRule(NotRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            var description = Describe(rule.Rule);
            if (NeedsParenthesis(rule, rule.Rule))
                description = string.Format("({0})", description);

            return string.Format("NOT[{1}] {0}", description, result);
        }

        protected override string DescribeXorRule(XorRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} XOR[{2}] {1}", leftDescription, rightDescription, result);
        }

        protected override string DescribeImpliesRule(ImpliesRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} IMPLIES[{2}] {1}", leftDescription, rightDescription, result);
        }

        protected override string DescribePreventsRule(PreventsRule<T> rule)
        {
            var result = DescribeResult(rule.IsTrueFor(evaluateWith));
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} PREVENTS[{2}] {1}", leftDescription, rightDescription, result);
        }

        private string DescribeResult(bool result)
        {
            return result.ToString().Substring(0, 1);
        }

        private bool NeedsParenthesis(ARuleAbout<T> parentRule, ARuleAbout<T> childRule)
        {
            return (parentRule.GetType() != childRule.GetType() && !childRule.GetType().Name.StartsWith("ARuleAbout"));
        }

    }
}
