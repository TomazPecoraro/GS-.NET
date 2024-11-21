using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var newUsuario = await _usuarioRepository.AddAsync(usuario);
            return _mapper.Map<UsuarioDto>(newUsuario);
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioDto>(updatedUsuario);
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return false;

            await _usuarioRepository.DeleteAsync(id);
            return true;
        }
    }
