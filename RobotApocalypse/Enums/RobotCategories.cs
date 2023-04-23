using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace RobotApocalypse.Enums
{
    public enum RobotCategories
    {
        [Display(Name = "All")]
        [Description("All")]
        All = 0,

        [Display(Name = "Land")]
        [Description("Land")]
        Land = 1,

        [Display(Name = "Flying")]
        [Description("Flying")]
        Flying = 2,
    }
}
