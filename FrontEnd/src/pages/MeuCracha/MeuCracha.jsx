import Header from '../../components/header/header';
import React, { useState, useEffect } from 'react';
import api from '../../services/api';

import '../../assets/css/MeuCracha.css';

import icone_setas from '../../assets/img/icone_setas.png';
import imagem_base from '../../assets/img/logo_sesi.png';
import imagem_yuri from '../../assets/img/img_perfil_yuri.png';
import img_padrao_cracha from '../../assets/img/img_padrao_cracha.png';

export default function MeuCracha() {

    const [itensCracha, setItensCracha] = useState([]);

    function buscarCrachaAluno() {
        console.log('chamada para a API');

        api.get('/Crachas', {
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

    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect(buscarCrachaAluno, []);

    return (
        <div>
            <Header />
            <main class="container_cracha">
                <div className='content'>
                    <img class="seta_retorno" src={icone_setas} alt="setas_retorno" />
                </div>
                <div className='a'>
                    <div className="border">
                        <div className="fundo">
                            <img className='logo' src={imagem_base} alt="" />
                            <img className='aluno' src={imagem_yuri} alt="" />
                            <span>Yuri Tamachiro</span>
                            <div>
                                <span>Aluno</span>
                                <span> </span>
                                <span>série</span>
                            </div>
                            <div className="elements">

                            </div>
                        </div>

                    </div>
                </div>
            </main>


        </div>

    );
}
