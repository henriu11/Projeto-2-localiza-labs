using System.Collections.Generic;

namespace Localiza_labs_2.Intefaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }   
    
}