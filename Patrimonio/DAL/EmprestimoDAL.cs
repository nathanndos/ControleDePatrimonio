using Entity;
using Patrimonio.Util;
using System;

namespace Patrimonio.DAL
{
    public class EmprestimoDAL : DbRepository<Emprestimo>
    {
        public Emprestimo save(Emprestimo emprestimo)
        {
            var obj = get(emprestimo.Id);

            if (obj?.Ide.isEmpty() ?? true)
            {
                if (emprestimo.Ide.isEmpty())
                    emprestimo.Ide = Guid.NewGuid();

                insert(emprestimo);
            }
            else
                update(emprestimo);

            return get(obj.Ide);
        }

        public void del(Emprestimo emprestimo, bool onlyAtivo = true)
        {
            var obj = get(emprestimo.Id);

            if (obj is null)
                return;

            if (onlyAtivo)
            {
                obj.Status = -1;
                update(obj);
            }
            else
                delete(obj);
        }
    }
}
