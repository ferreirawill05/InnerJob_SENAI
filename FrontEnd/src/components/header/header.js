import React, { Component } from "react";
import { Link } from "react-router-dom";

import Logo_Sesi from '../../assets/img/logo_sesi.png';
import icone_lista from '../../assets/img/icone_lista.png';
import icone_agenda from '../../assets/img/icone_agenda.png';
import icone_perfil from '../../assets/img/icone_perfil.png';

import '../../assets/css/Login.css'

export default class header extends Component {


    render() {

        return (
            <header>
                <div class="container container_header">
                    <Link to={'/'}><img src={Logo_Sesi} alt="logo"/></Link>
                    <nav class="menu_header">
                        <img class="icone_cracha" src={icone_lista} alt="icone lista"/>
                            <Link to={'/meucracha'}>Meu crachá</Link>
                            <img class="icone_carometro" src={icone_agenda} alt="icone carometro"/>
                                <Link to={'/listar'}>Carômetro</Link>
                                <img class="icone_perfil" src={icone_perfil} alt="icone perfil"/>
                                    <Link to={'/perfil'}>Perfil</Link>
                                </nav>
                            </div>
                        </header>

                        )
    }
}