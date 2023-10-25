using ConstantManager.Exception;
using DAL;
using Entity;
using Patrimonio.ConstantManager.Exception;
using Patrimonio.DAL;
using Patrimonio.Util;
using System;
using System.Collections.Generic;

namespace Patrimonio.BLL
{
    public class EmprestimoBLL
    {
        public static void isValid(Emprestimo emprestimo)
        {
            if (emprestimo.Pessoa.Id.isZero())
                throw new Exception(EmprestimoExceptionConstant.PessoaNaoInformada);
            else if(emprestimo.Equipamento.Id.isZero())
                throw new Exception(EmprestimoExceptionConstant.EquipamentoNaoInformado);
        }
        public static void save(Emprestimo emprestimo)
        {
            isValid(emprestimo);
            EmprestimoDAL db = new EmprestimoDAL();

            emprestimo.DataAbertura = DateTime.Now;

            db.save(emprestimo);
        }

        public static Emprestimo get(int id)
        {
            EmprestimoDAL db = new EmprestimoDAL();
            return db.get(id);
        }

        public static List<Emprestimo> listBySearch(string textSearch)
        {
            EmprestimoDAL db = new EmprestimoDAL();

            db.select = emprestimo => emprestimo;
            db.where = emprestimo => emprestimo.Status.Equals(0);
            db.orderBy = emprestimo => emprestimo.Id.ToString();

            //if (textSearch.isNotEmpty())
            //    db.where = db.where.and(emprestimo => emprestimo.Nome.Contains(textSearch));
            var teste = db.list();
            return db.list();
        }
    }
}
