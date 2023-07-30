using Microsoft.EntityFrameworkCore.Update.Internal;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Patrimonio.DAL
{
    public class EquipamentoDAL
    {
        public static Equipamento get(int id) => dbContext.get<Equipamento>(id);

        public static List<Equipamento> getAll() => dbContext.getAll<Equipamento>();

        public static void save(Equipamento equipamento)
        {
            var obj = get(equipamento.Id);

            if (obj?.Ide.isEmpty() ?? true)
                insert(equipamento);
            else
                update(equipamento);
        }

        public static void delete(Equipamento equipamento) => dbContext.delete(equipamento);

        private static void update(Equipamento equipamento) => dbContext.update(equipamento);

        private static void insert(Equipamento equipamento)
        {
            if (equipamento.Ide.isEmpty())
                equipamento.Ide = Guid.NewGuid();

            dbContext.insert(equipamento);
        }
    }
}
