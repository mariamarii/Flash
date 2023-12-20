using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Flash.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FlashUser class
public class FlashUser : IdentityUser
{
	public string? StreetAddress { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? PostalCode { get; set; }

}

