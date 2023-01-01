using FluentValidation;
using FluentValidation.Attributes;
using Models;
using System;
namespace TokenAuth.Validator
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.UserId).GreaterThanOrEqualTo(1);

            RuleFor(order => order.Quantity).GreaterThanOrEqualTo(1);

        }
    }
}