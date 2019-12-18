import React, { Component } from 'react';


class CadastroEquipamento extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nomeEquipamento: '',
            marca: '',
            modelo: '',
            sistemaOperacional: '',
            polegada: '',
            processador: '',
            memoriaRam: '',
            ssd: '',
            hd: '',
            placaDeVideo: '',
            alimentacao: '',
            peso: '',
            dimensoes: '',
        }

        this.cadastrarEquipamento = this.cadastrarEquipamento.bind(this);
        this.atualizaEstadoNomeEquipamento = this.atualizaEstadoNomeEquipamento.bind(this);
        this.atualizaEstadoMarca = this.atualizaEstadoMarca.bind(this);
        this.atualizaEstadoModelo = this.atualizaEstadoModelo.bind(this);
        this.atualizaEstadoSistemaOperacional = this.atualizaEstadoSistemaOperacional.bind(this);
        this.atualizaEstadoPolegada = this.atualizaEstadoPolegada.bind(this);
        this.atualizaEstadoProcessador = this.atualizaEstadoProcessador.bind(this);
        this.atualizaEstadoMemoriaRam = this.atualizaEstadoMemoriaRam.bind(this);
        this.atualizaEstadoSSD = this.atualizaEstadoSSD.bind(this);
        this.atualizaEstadoHD = this.atualizaEstadoHD.bind(this);
        this.atualizaEstadoPlacaDeVideo = this.atualizaEstadoPlacaDeVideo.bind(this);
        this.atualizaEstadoAlimentacao = this.atualizaEstadoAlimentacao.bind(this);
        this.atualizaEstadoPeso = this.atualizaEstadoPeso.bind(this);
        this.atualizaEstadoDimensoes = this.atualizaEstadoDimensoes.bind(this);
    }

    atualizaEstadoNomeEquipamento(event) {
        this.setState({ nomeEquipamento: event.target.value })
    }

    atualizaEstadoMarca(event) {
        this.setState({ marca: event.target.value })
    }

    atualizaEstadoModelo(event) {
        this.setState({ modelo: event.target.value })
    }

    atualizaEstadoSistemaOperacional(event) {
        this.setState({ sistemaOperacional: event.target.value })
    }

    atualizaEstadoPolegada(event) {
        this.setState({ polegada: event.target.value })
    }

    atualizaEstadoProcessador(event) {
        this.setState({ processador: event.target.value })
    }

    atualizaEstadoMemoriaRam(event) {
        this.setState({ memoriaRam: event.target.value })
    }

    atualizaEstadoSSD(event) {
        this.setState({ ssd: event.target.value })
    }

    atualizaEstadoHD(event) {
        this.setState({ hd: event.target.value })
    }

    atualizaEstadoPlacaDeVideo(event) {
        this.setState({ placaDeVideo: event.target.value })
    }

    atualizaEstadoAlimentacao(event) {
        this.setState({ alimentacao: event.target.value })
    }

    atualizaEstadoPeso(event) {
        this.setState({ peso: event.target.value })
    }

    atualizaEstadoDimensoes(event) {
        this.setState({ dimensoes: event.target.value })
    }

    cadastrarEquipamento(event) {
        event.preventDefault();
        fetch('https://localhost:5001/api/Equipamento', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                     },
            body: JSON.stringify({
                nomeEquipamento: this.state.nomeEquipamento,
                marca: this.state.marca,
                modelo: this.state.modelo,
                sistemaOperacional: this.state.sistemaOperacional,
                polegada: this.state.polegada,
                processador: this.state.processador,
                memoriaRam: this.state.memoriaRam,
                ssd: this.state.ssd,
                hd: this.state.hd,
                placaDeVideo: this.state.placaDeVideo,
                alimentacao: this.state.alimentacao,
                peso: this.state.peso,
                dimensoes: this.state.dimensoes,
                                }),
            headers: { 'Content-type': 'application/json' }
                                                            }
            )
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('Cadastro de usuário concluído com sucesso')
                }
            })
    }

    render() {
        return (
            <div>
                <body>
                    <main id="conteudo_adm">
                                    <form onSubmit={this.cadastrarEquipamento}>
                                        <label type="text">Nome do equipamento:</label>
                                        <input type="text"
                                            value={this.state.nomeEquipamento}
                                            onChange={this.atualizaEstadoNomeEquipamento}
                                            placeholder="Nome do equipamento"
                                        />
                                        <label type="text">Marca:</label>
                                        <input type="text" value={this.state.marca}
                                            onChange={this.atualizaEstadoMarca}
                                            name=""
                                            id=""
                                            placeholder="Marca"
                                        />
                                        <label type="text">Modelo:</label>
                                        <input type="text"
                                            value={this.state.modelo}
                                            onChange={this.atualizaEstadoModelo}
                                            placeholder="Modelo"
                                        />
                                        <label type="text">Sistema Operacional:</label>
                                        <input type="text"
                                            value={this.state.sistemaOperacional}
                                            onChange={this.atualizaEstadoSistemaOperacional}
                                            placeholder="Sistema Operacional"
                                        />
                                        <label type="text">Polegada:</label>
                                        <input type="text" value={this.state.polegada}
                                            onChange={this.atualizaEstadoPolegada}
                                            placeholder="Polegada"
                                        />
                                        <label type="text">Processador:</label>
                                        <input type="text" value={this.state.processador}
                                            onChange={this.atualizaEstadoProcessador}
                                            placeholder="Processador"
                                        />
                                        <label type="text">Memoria RAM:</label>
                                        <input type="text" value={this.state.memoriaRam}
                                            onChange={this.atualizaEstadoMemoriaRam}
                                            placeholder="Memoria RAM"
                                        />
                                        <label type="text">SSD:</label>
                                        <input type="text" value={this.state.ssd}
                                            onChange={this.atualizaEstadoSSD}
                                            placeholder="SSD"
                                        />
                                        <label type="text">HD:</label>
                                        <input type="text" value={this.state.hd}
                                            onChange={this.atualizaEstadoHD}
                                            placeholder="HD"
                                        />
                                        <label type="text">Placa de video:</label>
                                        <input type="text" value={this.state.placaDeVideo}
                                            onChange={this.atualizaEstadoPlacaDeVideo}
                                            placeholder="Placa de video"
                                        />
                                        <label type="text">Alimentação:</label>
                                        <input type="text" value={this.state.alimentacao}
                                            onChange={this.atualizaEstadoAlimentacao}
                                            placeholder="Alimentação"
                                        />
                                        <label type="text">Peso:</label>
                                        <input type="text" value={this.state.peso}
                                            onChange={this.atualizaEstadoPeso}
                                            placeholder="Peso"
                                        />
                                        <label type="text">Dimensões:</label>
                                        <input type="text" value={this.state.dimensoes}
                                            onChange={this.atualizaEstadoDimensoes}
                                            placeholder="Dimensões"
                                        />
                                        <button type="submit" onClick="cadastrarEquipamento()">Cadastrar</button>
                                    </form>
                    </main>
                </body>
            </div>
        )
    }
}

export default CadastroEquipamento;