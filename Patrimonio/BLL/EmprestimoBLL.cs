using BLL;
using Entity;
using Patrimonio.ConstantManager.Exception;
using Patrimonio.DAL;
using Patrimonio.Util;
using System;
using System.Collections.Generic;

namespace Patrimonio.BLL;

public class EmprestimoBLL
{
    private static void isValid(Emprestimo emprestimo)
    {
        if (emprestimo.PessoaId.isZero())
            throw new Exception(EmprestimoExceptionConstant.PessoaNaoInformada);
        else if (emprestimo.EquipamentoId.isZero())
            throw new Exception(EmprestimoExceptionConstant.EquipamentoNaoInformado);
    }

    public static void isValidSave(Emprestimo emprestimo)
    {
        isValid(emprestimo);
        if (isEmprestado(emprestimo.EquipamentoId))
            throw new Exception(EmprestimoExceptionConstant.EquipamentoJaEmprestado);
    }

    public static bool isEmprestado(int equipamentoId)
    {
        Equipamento equipamento = EquipamentoBLL.get(equipamentoId);

        EmprestimoDAL db = new EmprestimoDAL();
        db.exist = i => i.EquipamentoId.Equals(equipamento.Id) && i.DataFechamento.Equals(new DateTime(1900, 1, 1));

        return db.exists();
    }

    public static Emprestimo save(Emprestimo emprestimo)
    {
        isValidSave(emprestimo);
        EmprestimoDAL db = new EmprestimoDAL();
        emprestimo.DataAbertura = DateTime.Now;

        return db.save(emprestimo);
    }

    public static Emprestimo get(int id)
    {
        EmprestimoDAL db = new EmprestimoDAL();
        return db.get(id);
    }

    public static List<Emprestimo> list()
    {
        EmprestimoDAL db = new EmprestimoDAL();

        db.select = emprestimo => emprestimo;
        db.where = emprestimo => emprestimo.Status.Equals(0) && emprestimo.DataFechamento.Equals(Tools.getDefaultDateTime());
        db.orderBy = emprestimo => emprestimo.Id.ToString();

        var teste = db.list();
        return db.list();
    }

    public static List<Emprestimo> listHistorico(Equipamento equipamento, Pessoa pessoa)
    {
        EmprestimoDAL db = new EmprestimoDAL();

        db.select = emprestimo => emprestimo;
        db.where = emprestimo => emprestimo.Status.Equals(0) ;
        db.orderBy = emprestimo => emprestimo.Id.ToString();

        if (equipamento.Id.isNotZero())
            db.where = db.where.and(emprestimo => emprestimo.EquipamentoId.Equals(equipamento.Id));
        if (pessoa.Id.isNotZero())
            db.where = db.where.and(emprestimo => emprestimo.PessoaId.Equals(pessoa.Id));

        var teste = db.list();
        return db.list();
    }

    public static Emprestimo finalizar(Emprestimo emprestimo)
    {
        isValidFinalizar(emprestimo); 
        
        EmprestimoDAL db = new EmprestimoDAL();
        emprestimo.DataFechamento = DateTime.Now;
        return db.save(emprestimo);
    }

    private static void isValidFinalizar(Emprestimo emprestimo)
    {
        if (emprestimo.isFinalizado)
            throw new Exception(EmprestimoExceptionConstant.EmprestimoJaFinalizado);
        else if (emprestimo.Ide.isEmpty())
            throw new Exception(EmprestimoExceptionConstant.PrecisoSalvarParaFinalizarEmprestimo);
    }
}