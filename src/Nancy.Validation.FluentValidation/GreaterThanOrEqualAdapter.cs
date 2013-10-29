﻿namespace Nancy.Validation.FluentValidation
{
    using System.Collections.Generic;
    using Nancy.Validation.Rules;
    using global::FluentValidation.Internal;
    using global::FluentValidation.Validators;

    /// <summary>
    /// Adapter between the Fluent Validation <see cref="GreaterThanOrEqualValidator"/> and the Nancy validation rules.
    /// </summary>
    public class GreaterThanOrEqualAdapter : AdapterBase
    {
        public override bool CanHandle(IPropertyValidator validator, NancyContext context)
        {
            return validator is GreaterThanOrEqualValidator;
        }

        /// <summary>
        /// Get the <see cref="ModelValidationRule"/> instances that are mapped from the fluent validation rule.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ModelValidationRule"/> instances.</returns>
        public override IEnumerable<ModelValidationRule> GetRules(PropertyRule rule, IPropertyValidator validator)
        {
            yield return new ComparisonValidationRule(
                base.FormatMessage(rule, validator),
                base.GetMemberNames(rule),
                ComparisonOperator.GreaterThanOrEqual,
                ((GreaterThanOrEqualValidator)validator).ValueToCompare);
        }
    }
}