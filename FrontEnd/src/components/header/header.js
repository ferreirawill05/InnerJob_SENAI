import React, { Component } from "react";
import { Link } from "react-router-dom";
import { parseJwt } from "../../services/auth";

import Logo_Sesi from '../../assets/img/logo_sesi.png';
import icone_lista from '../../assets/img/icone_lista.png';
import icone_agenda from '../../assets/img/icone_agenda.png';
import icone_perfil from '../../assets/img/icone_perfil.png';

import '../../assets/css/Login.css'

export default class header extends Component {

    mostrarCracha = () => {
        if (parseJwt() != null) {
            switch (parseJwt().role) {
                case '2':
                    window.location.href = "/meucracha"
                    break;
                case '3':
                    window.location.href = "/meucracha"
                    break;
                default:
                    window.location.href = "/login"
                    break;
            }

        } else {
            alert("Usuário não está logado.")
        }
    }

    listar = () => {
        if (parseJwt() != null) {
            switch (parseJwt().role) {
                case '1':
                    window.location.href = "/cadastrar"
                    break;
                case '2':
                    // window.location.href = "/permissao"
                    alert("Somente professores e admnistradores podem acessar o carômetro!")
                    break;
                case '3':
                    window.location.href = "/listar"
                    break;
                default:
                    window.location.href = "/"
                    break;
            }

        } else {
            alert("Usuário não está logado.")
        }
    }


    render() {

        return (
            <header>
                <div class="container container_header">
                    <Link to={'/'}><img src={Logo_Sesi} alt="logo" /></Link>
                    <nav class="menu_header">
                        <img class="icone_cracha" src={icone_lista} alt="icone lista" />
                        <button onClick={() => this.mostrarCracha()}>Meu crachá</button>
                        <img class="icone_carometro" src={icone_agenda} alt="icone carometro" />
                        <button onClick={() => this.listar()}>Carômetro</button>
                        <img class="icone_perfil" src={icone_perfil} alt="icone perfil" />
                        <Link to={'/perfil'}>Perfil</Link>
                    </nav>
                </div>
            </header>

        )
    }
}