using Entity;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;

namespace DAL;

public class PessoaDAL : DbRepository<Pessoa>
{
    public static void save(Pessoa pessoa)
    {
        var obj = get(pessoa.Id);

        if (obj?.Ide.isEmpty() ?? true)
        {
            if (pessoa.Ide.isEmpty())
                pessoa.Ide = Guid.NewGuid();

            insert(pessoa);
        }
        else
            update(pessoa);
    }

    public static void del(Pessoa pessoa, bool onlyAtivo = true)
    {
        var obj = get(pessoa.Id);

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
