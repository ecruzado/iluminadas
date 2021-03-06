﻿using Iluminada.Web.Common;
using Iluminada.Web.Data;
using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Logica
{
    public class UsuarioLogica : Singleton<UsuarioLogica>
    {
        private readonly UsuarioData usuarioData = new UsuarioData();

        public List<Usuario> List(int colegioId)
        {
            return usuarioData.List(colegioId);
        }

        public Usuario GetById(int usuarioId)
        {
            return usuarioData.GetById(usuarioId);
        }

        public Usuario GetByUsuarioAndPassword(string nombreUsuario, string password)
        {
            return usuarioData.GetByUsuarioAndPassword(nombreUsuario, password);
        }

        public int Insert(Usuario usuario)
        {
            return usuarioData.Insert(usuario);
        }

        public int Update(Usuario usuario)
        {
            return usuarioData.Update(usuario);
        }
        public int UpdatePassword(int usuarioId, string password)
        {
            return usuarioData.UpdatePassword(usuarioId, password);
        }
    }

}