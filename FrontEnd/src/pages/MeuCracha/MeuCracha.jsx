import Header from '../../components/header/header';
import React, { useState, useEffect } from 'react';
import api from '../../services/api';

import '../../assets/css/MeuCracha.css';

import icone_setas from '../../assets/img/icone_setas.png';
import imagem_base from '../../assets/img/logo_sesi.png';
import imagem_yuri from '../../assets/img/img_perfil_yuri.png';
// import img_padrao_cracha from '../../assets/img/img_padrao_cracha.png';
import { Link } from 'react-router-dom';
import { parseJwt } from '../../services/auth';

export default function MeuCracha() {
    
    const [itensCracha, setItensCracha] = useState([]);
    var [tipo = ''] = useState([]);
    
    function buscarCrachaAluno() {

        api.get('/usuarios/uses', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setItensCracha(resposta.data)
                }
            })

            // caso ocorra algum erro, exibe no console do navegador este erro
            .catch(erro => console.log(erro));
    };

    function mostrarCracha() {
        return(
            itensCracha.map((itens) => {
                switch(itens.idTipoUsuario){
                    case 2:
                        tipo = 'ALUNO'
                        break;
                    case 3:
                        tipo = 'PROFESSOR'
                        break;
                }
                return (
                    <div className="fundo" key={itens.idUsuario}>
                        <img className='logo' src={imagem_base} alt="" />
                        <img className='aluno' src={imagem_yuri} alt="" />
                        <span>{itens.nomeUsuario}</span>
                        <div className='space'>
                            
                            <span>{tipo}</span>
                            <span> </span>
                            <span>Manhã</span>
                        </div>
                        <span></span>
                    </div>
                )
            })
        )
    }
    
    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect(buscarCrachaAluno, []);
    
    return (
        <div>
            <Header />
            <Link to={'/'}><img class="seta_retorno" src={icone_setas} alt="setas_retorno" /></Link>
            <main class="container_cracha">

                <div className='a'>
                    <div className="border">
                        {
                            mostrarCracha()
                        }

                    </div>
                </div>
            </main>


        </div>

    );
}
