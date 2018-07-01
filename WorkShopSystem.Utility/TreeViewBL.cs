using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkShopSystem.Utility
{
    public static class TreeViewBL
    {
        // 递归判断是否有节点被选中
        public static bool ff(TreeNodeCollection tr)
        {
            bool flag = false;
            for (int i = 0; i < tr.Count; i++)
            {
                if (tr[i].IsSelected)
                {
                    return true;
                }
                else
                {
                    bool b = ff(tr[i].Nodes);
                    if (b == true)
                    {
                        return b;
                    }
                }
            }
            return flag;
        }


    }
}
