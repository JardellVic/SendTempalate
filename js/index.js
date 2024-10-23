// Envio de mensagem via formulário
document.getElementById('messageForm').addEventListener('submit', async function (event) {
    event.preventDefault(); // Impede o envio padrão do formulário

    const destination = document.getElementById('destination-number').textContent; // Pegando o número do destinatário
    const message = document.getElementById('message').value; // Pegando o texto da mensagem

    try {
        const response = await fetch('http://52.67.59.173:3000/send-message', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({
                message: JSON.stringify({
                    text: message,
                    type: "text",
                    previewUrl: false
                }),
                source: '553171433602',
                destination: destination,
                'src.name': 'BotRJSOL'
            })
        });

        const data = await response.json();
        const responseDiv = document.getElementById('response');
        responseDiv.style.display = 'block';

        if (response.ok) {
            responseDiv.textContent = 'Mensagem enviada com sucesso!';
            responseDiv.style.color = 'green';

            // Exibir a mensagem enviada
            const messagesList = document.getElementById('messages');
            if (!messagesList) {
                // Cria a div e a lista se não existirem
                createMessageContainer();
            }
            const listItem = document.createElement('li');
            listItem.textContent = message;
            listItem.classList.add('sent');
            document.getElementById('messages').appendChild(listItem);

            document.getElementById('message').value = ''; // Limpar o campo de mensagem
        } else {
            responseDiv.textContent = `Erro: ${data.error}`;
            responseDiv.style.color = 'red';
        }
    } catch (error) {
        console.error('Erro ao enviar a mensagem:', error);
        const responseDiv = document.getElementById('response');
        responseDiv.style.display = 'block';
        responseDiv.textContent = 'Erro ao enviar a mensagem. Tente novamente mais tarde.';
        responseDiv.style.color = 'red';
    }
});

// Função para criar a div de mensagens e a lista
function createMessageContainer() {
    const chatContainer = document.createElement('div');
    chatContainer.className = 'chat-messages';
    
    const messagesList = document.createElement('ul');
    messagesList.id = 'messages';
    
    chatContainer.appendChild(messagesList);
    document.body.appendChild(chatContainer); // Você pode ajustar onde a div é adicionada conforme necessário
}

// Recepção de mensagens do servidor via Socket.io
const socket = io('http://52.67.59.173:3000'); // Conexão com o servidor Socket.io

socket.on('connect', () => {
    console.log('Conectado ao servidor!');
});

// Não crie um li vazio na inicialização
socket.on('message', (data) => {
    // Atualizar o cabeçalho com o nome e o número do destinatário
    document.getElementById('chat-name').textContent = data.name; // Nome do remetente
    document.getElementById('destination-number').textContent = data.phone; // Número do remetente

    // Verifica se a lista de mensagens já existe, se não, cria
    const messagesList = document.getElementById('messages');
    if (!messagesList) {
        createMessageContainer();
    }
    
    // Exibir a mensagem recebida somente se data.text estiver definido
    if (data.text !== undefined) {
        const listItem = document.createElement('li');
        listItem.textContent = data.text;
        listItem.classList.add('received'); // Adicionar estilo de mensagem recebida
        document.getElementById('messages').appendChild(listItem);
    }
});

socket.on('connect_error', (err) => {
    console.error('Erro de conexão:', err);
});
