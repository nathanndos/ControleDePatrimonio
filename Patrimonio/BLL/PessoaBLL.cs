using ConstantManager.Exception;
using DAL;
using Entity;
using Patrimonio.Util;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
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
        PessoaDAL.save(Pessoa);
    }

    public static List<Pessoa> getAll()
    {
        return PessoaDAL.getAll().Where(i => i.Status.Equals(0)).ToList();
    }

    public static Pessoa get(int id)
    {
        return PessoaDAL.get(id);
    }

    public static void delete(Pessoa Pessoa)
    {
        PessoaDAL.del(Pessoa);
    }

    public static List<Pessoa> listBySearch(string textSearch)
    {
        Expression<Func<Pessoa, bool>>? expressionWhere = pessoa => pessoa.Status.Equals(0);

        if (textSearch.isNotEmpty()) //procurando apagado
        {
            expressionWhere =  Pessoa =>
                              Pessoa.Nome.Contains(textSearch) ||
                              Pessoa.Id.ToString().Contains(textSearch) &&
                              Pessoa.Status.Equals(0);
        }

        var result = from Pessoa in dbContext.get.Pessoa
                     orderby Pessoa.Nome
                     select Pessoa;

        return expressionWhere is null ? result.ToList() : result.Where(expressionWhere).ToList();
    }
}
