using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Validators
{
    public class AssetViewModelValidator :AbstractValidator<AssetViewModel>
    {
        private readonly IAssetRepository _asset;

        public AssetViewModelValidator(IAssetRepository asset)
        {
            _asset = asset;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .MinimumLength(5).WithMessage("Name value is null or too short");
            RuleFor(x => x.Department).NotEmpty().IsInEnum().WithMessage("Department is not valid");
            RuleFor(x => x.Country).MustAsync(async (Country, cancellation) => {
                bool exists = await _asset.IsCountryValid(Country);
                return exists;
            }).WithMessage("Country Name Must be a valid Fullname");
            RuleFor(x => x.Date).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.AddYears(-1))
                .WithMessage("Asset Purchased Date should not be older than one year");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Department email must be a valid email");
            RuleFor(x => x.isBroken).NotNull();
        }
    }
}
