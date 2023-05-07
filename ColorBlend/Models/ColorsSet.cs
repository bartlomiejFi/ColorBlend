using System.ComponentModel.DataAnnotations;

namespace ColorBlend.Models
{
    public class ColorsSet
    {
        #region Fields

        #endregion

        #region Properties
        [Required]
        public string Color1 { get; set; }
        [Required]
        public string Color2 { get; set; }

        public string ColorMixed { get; set; }

        public string MixingResultInfo { get; set; }

        public string Color1Info { get; set; }

        public string Color2Info { get; set; }

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
