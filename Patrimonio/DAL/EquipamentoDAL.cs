using Entity;
using Patrimonio.Util;
using System;

namespace DAL
{
    public class EquipamentoDAL : DbRepository<Equipamento>
    {
        public void save(Equipamento equipamento)
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

        public void del(Equipamento equipamento, bool onlyAtivo = true)
        {
            var obj = get(equipamento.Id);

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
