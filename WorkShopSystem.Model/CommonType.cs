using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkShopSystem.Model
{
    public enum WorkShop
    {
        JiJia = 0,
        YaZhu = 1,
    }
    public enum YaZhuQueXianType
    {
        NeiBuQueXian = 0,
        PinZhiChouJian = 1,
    }
    public enum JiJIaQueXianType
    {
        JiJiaQueXian = 0,
        YaZhuQueXian = 1,
        PinZhiChouJian = 2,
    }
    public enum YaZhuLiuCheng
    {
        YaZhu = 0,
        DaSha1 = 1,
        DaSha2 = 2,
        PiFeng = 3,
        PiFengH = 4,
    }
}
