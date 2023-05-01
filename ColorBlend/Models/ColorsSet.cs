using System.ComponentModel.DataAnnotations;

namespace ColorBlend.Models
{
    public class ColorsSet
    {
        #region Fields

        #endregion

        #region Properties
        [Required]
        public string C1 { get; set; }
        [Required]
        public string C2 { get; set; }

        public string C3 { get; set; }

        public DateTime TimeMixed { get; set; }

        public Guid Id { get; set; }

        #endregion

        #region Constructors

        public ColorsSet()
        {
            Id = new Guid();
            TimeMixed = DateTime.Now.ToLocalTime();
        }

        #endregion
    }
}
