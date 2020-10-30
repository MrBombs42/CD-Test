# CD-Test
Primeira etapa:
- Carregar JSON remoto(chamada http) na url que segue;   https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json 
- Deserializar JSON e carregar dados de objetos em uma cena: posição, rotação, escala; 
- A partir destes dados, carregar modelos 3D (FBX) na cena, e configurar conforme posição, escala e rotação; 
- Modelos a serem utilizados: modelos gratuítos disponibilisados na AssetStore. 
- Carregar modelos via Resources;  
Segunda etapa: 
- Permitir interação pelo usuário depois de carregada a cena:  
.mover objetos, mudar escala e mudar rotação;  
.permitir duplicar objetos na cena;  
.permitir trocar cor e textura base(albedo) do material.  
.permitir serializar e salvar a cena, utilizando mesma estrutrura de JSON conhecida, em arquivo local no filesystem.  
Terceira etapa: - Desenvolver interface com usuário (UI) utilizando framework de interface da Unity3D (uGui). 
- Esta interface deve realizar as seguintes funções:   
.Mostrar feedback de "aguarde" enquanto a cena é carregada;  
.Mostrar lista de objetos carregados usando Thumbnails: texturas referentes a cada modelo deve ser carregada via Resources;  
.Trocar cor e textura dos materiais de cada objeto selecionado via UI:    
*máximo 3 opções de cores, máximo 3 opções de texturas para cada objeto.   
.Salvar cena.
