using Patrimonio.Entity;
using Patrimonio.Util;
using System;

namespace Patrimonio.DAL
{
    public class EquipamentoDAL : DbRepository<Equipamento>
    {
        public static void save(Equipamento equipamento)
        {
            var obj = get(equipamento.Id);

            if (obj?.Ide.isEmpty() ?? true)
            {
                if (equipamento.Ide.isEmpty())
                    equipamento.Ide = Guid.NewGuid();

                insert(equipamento);
            }
            else
                update(equipamento);
        }

        public static void del(Equipamento equipamento, bool onlyChangeStatus = true)
        {
            var obj = get(equipamento.Id);

            if (obj is null)
                return;

            if (onlyChangeStatus)
            {
                obj.Status = - 1;
                update(obj);
            }
            else
                delete(obj);
        }
    }
}
