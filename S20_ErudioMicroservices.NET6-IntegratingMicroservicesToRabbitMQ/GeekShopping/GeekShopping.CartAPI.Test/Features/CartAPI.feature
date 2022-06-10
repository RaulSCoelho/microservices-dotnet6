#language: pt-br

Funcionalidade: CartAPI
	Operacoes GET/POST/PUT/DELETE de carrinho de compras

@tag1
Cenario: Operacoes no carrinho de compras
	Dado que o userId do carrinho e 9798c62b-8e95-4608-bf69-0802e9084013
	E o metodo e POST
	Quando o metodo for executado
	Entao statuscode da resposta devera ser OK