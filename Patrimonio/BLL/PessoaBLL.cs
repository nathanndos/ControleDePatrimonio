using ConstantManager.Exception;
using DAL;
using Entity;
using Patrimonio.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL;

public class PessoaBLL
{
    public static void isValid(Pessoa pessoa)
    {
        if (pessoa.Nome.isEmpty())
            throw new Exception(PessoaExceptionConstant.NomeInvalido);
    }
    public static void save(Pessoa Pessoa)
    {
        isValid(Pessoa);
        PessoaDAL db = new PessoaDAL();
        db.save(Pessoa);
    }

    public static List<Pessoa> getAll()
    {
        PessoaDAL db = new PessoaDAL();
        return db.getAll().Where(i => i.Status.Equals(0)).ToList();
    }

    public static Pessoa get(int id)
    {
        PessoaDAL db = new PessoaDAL();
        return db.get(id);
    }

    public static void delete(Pessoa pessoa)
    {
        if (pessoa.Emprestimos.Any())
            throw new Exception(PessoaExceptionConstant.PessoaComMovimentacaoDeEmprestimo);

        PessoaDAL db = new PessoaDAL();
        db.del(pessoa);
    }

    public static List<Pessoa> listBySearch(string textSearch)
    {
        PessoaDAL db = new PessoaDAL();

        db.select = Pessoa => Pessoa;
        db.where = Pessoa => Pessoa.Status.Equals(0);
        db.orderBy = Pessoa => Pessoa.Nome;

        if (textSearch.isNotEmpty())
            db.where = db.where.and(Pessoa => Pessoa.Nome.Contains(textSearch));

        return db.list();
    }
}
