﻿namespace TrabalhoApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public static implicit operator UsuarioModel(PedidosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
