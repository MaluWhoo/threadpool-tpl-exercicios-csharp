# Exercício 1 - Contador Paralelo

## 📋 Descrição
Implementação de um contador que utiliza programação paralela para simular múltiplas threads incrementando um contador compartilhado.

## 🎯 Objetivo
Demonstrar o problema de **race condition** e a necessidade de sincronização em programas multi-thread.

## ⚡ Conceitos Utilizados
- `Task.Run`
- `lock` statement
- `Interlocked.Increment`
- Race conditions

## 🛠️ Implementação
O exercício apresenta três abordagens:
1. **Não sincronizada** (com race condition)
2. **Com lock** 
3. **Com Interlocked**
