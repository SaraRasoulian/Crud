using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sage.challenge.data.Entities
{
    [Table("User")]
    public class User: ObjectModel
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
        [MaxLength(128)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the User.
        /// </summary>
        [MaxLength(128)]
        public string LastName { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User's D.O.B.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}