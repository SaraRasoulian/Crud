using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sage.challenge.data.Entities
{
    [Table("User")]
    public class User //: ObjectModel
    {
        /// <summary>
        /// ID of the User.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// First name of the User.
        /// </summary>
        [Required(ErrorMessage = "First name is required")]
        [StringLength(128, ErrorMessage = "First name can't be longer than 128 characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the User.
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(128, ErrorMessage = "Last name can't be longer than 128 characters")]
        public string LastName { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [StringLength(320, ErrorMessage = "Email can't be longer than 320 characters")]
        public string Email { get; set; }

        /// <summary>
        /// User's D.O.B.
        /// </summary>
        [Required(ErrorMessage = "Date of birth is required")]
        // Validate the date format "YYYY-MM-DD"
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
    }
}