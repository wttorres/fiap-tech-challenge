using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Fixtures;

public class AtualizarHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected AtualizarHandler UsuarioHandler { get; private set; }

    public AtualizarHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        UsuarioHandler = new AtualizarHandler(UsuarioRepositoryMock.Object);
    }
}
