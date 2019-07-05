using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Ihuman_fileBLL
    {
        List<human_file> Select();
        List<human_file> SelectWhere(Expression<Func<human_file, bool>> where);
        int Insert(human_file h);
        List<human_file> SelectFenYe(Expression<Func<human_file, int>> order, Expression<Func<human_file, bool>> where, out int rows, int currentPage, int pageSize);

        int Update(human_file hf);
        int Del(human_file hf);
    }
}
