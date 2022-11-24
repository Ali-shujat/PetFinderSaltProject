using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace PetFinderApi.Data.ViewModels;

public class LocationValidation: ValidationAttribute
{
  //  public override bool IsValid(decimal[] arr) => arr.Length == 2;
}