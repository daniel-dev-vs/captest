﻿using CapptaApi.Models;
using CapptaApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Constantes;


namespace CapptaApi.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private List<Transacao> _transacoes { get; set; }
        public TransacaoRepository(List<Transacao> transacoes)
        {
            if (transacoes == null) { throw new ArgumentNullException(nameof(_transacoes)); }
            _transacoes = transacoes;
        }

        /// <summary>
        /// Método asíncrono responsável por consultar por adquirente e bandeira.
        /// </summary>
        /// <param name="adquirente">deve ser preenchido</param>
        /// <param name="bandeira"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorAdquirente(string adquirente, string bandeira)
        {
            var result =  _transacoes.Where(x => x.AcquirerName.ToLower() == adquirente.ToLower() &&
            x.CardBrandName.ToLower() == bandeira.ToLower()).ToList();

            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bandeira"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorBandeira(string bandeira)
        {
            var result = _transacoes.Where(x => x.CardBrandName.ToLower() == bandeira.ToLower()).ToList();

            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorCnpj(string cnpj)
        {
            var result = _transacoes.Where(x => x.MerchantCnpj == cnpj).ToList();

            return Task.FromResult(result);
        }

        public Task<List<Transacao>> ConsultaPorCnpjDataAtualMastercard(string cnpj)
        {
            var dataAtual = DateTime.Now;
            var result = _transacoes.Where(x => x.AcquirerAuthorizationDateTime > dataAtual && x.AcquirerAuthorizationDateTime < dataAtual.AddHours(23) &&
            x.MerchantCnpj == cnpj && x.CardBrandName == Const.Mastercard).ToList();

            return Task.FromResult(result);

           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bandeira"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorData(DateTime data, string bandeira)
        {
            var result = _transacoes.Where(x => x.AcquirerAuthorizationDateTime > data &&  x.AcquirerAuthorizationDateTime < data.AddHours(23) &&
            x.CardBrandName.ToLower() == bandeira.ToLower()).ToList();

            return Task.FromResult(result);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="bandeira"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorCnpjEBandeira(string cnpj, string bandeira)
        {
            var result = _transacoes.Where(x => x.MerchantCnpj == cnpj && x.CardBrandName.ToLower()
            == bandeira.ToLower() ).ToList();

            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorCnpjMasterEVisa(string cnpj)
        {
            var result = _transacoes.Where(x => x.MerchantCnpj == cnpj &&
            x.CardBrandName == Constantes.Const.Mastercard || x.CardBrandName == Const.Visa).ToList();

            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public Task<List<Transacao>> ConsultaPorCnpjStoneUltimos30Dias(string cnpj)
        {
            DateTime Ultimos30Dias = DateTime.Now.AddDays(-30);
            

            var result = _transacoes.Where(x => x.MerchantCnpj == cnpj &&
            x.AcquirerName == Const.Stone &&
            x.AcquirerAuthorizationDateTime > Ultimos30Dias).ToList();

            return Task.FromResult(result);
        }
    }
}

