using The.Rules.DescribeRules;
using The.Rules.Operators;
using The.Rules.Operators.T;

namespace The.Rules.CustomDescriber
{
    public class SimplifiedRuleDescriber<T> : AbstractRuleDescriber<T>
    {
        protected override string DescribeRule(ARuleAbout<T> rule)
        {
            return rule.Text;
        }

        protected override string DescribeAndRule(AndRule<T> rule)
        {
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);
            
            return string.Format("{0} AND {1}", leftDescription, rightDescription);
        }

        protected override string DescribeOrRule(OrRule<T> rule)
        {
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} OR {1}", leftDescription, rightDescription);
        }

        protected override string DescribeNotRule(NotRule<T> rule)
        {
            return string.Format("NOT ({0})", Describe(rule.Rule));
        }

        protected override string DescribeXorRule(XorRule<T> rule)
        {
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} XOR {1}", leftDescription, rightDescription);
        }

        protected override string DescribeImpliesRule(ImpliesRule<T> rule)
        {
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} IMPLIES {1}", leftDescription, rightDescription);
        }

        protected override string DescribePreventsRule(PreventsRule<T> rule)
        {
            var leftDescription = Describe(rule.Left);
            if (NeedsParenthesis(rule, rule.Left))
                leftDescription = string.Format("({0})", leftDescription);

            var rightDescription = Describe(rule.Right);
            if (NeedsParenthesis(rule, rule.Right))
                rightDescription = string.Format("({0})", rightDescription);

            return string.Format("{0} PREVENTS {1}", leftDescription, rightDescription);
        }

        private bool NeedsParenthesis(ARuleAbout<T> parentRule, ARuleAbout<T> childRule)
        {
            return (parentRule.GetType() != childRule.GetType() && !childRule.GetType().Name.StartsWith("ARuleAbout"));
        }
    }
}
