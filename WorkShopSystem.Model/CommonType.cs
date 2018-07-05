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
    public enum WorkShopType
    {
        压铸 = 0,
        打砂1 = 1,
        打砂2 = 2,
        披锋 = 3,
        H面全检 = 4,
        CNC = 5,
        清洗 = 6,
        测漏 = 7,
        拉线全检 = 8,
    }
}
