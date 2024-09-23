// 'use client';
// import { useState } from "react";

// export default function Home() {
//   const [isLoading, setIsLoading] = useState(false);

//   const handleCreatOrderClick = async () => {
//     setIsLoading(true);
//     try {
//       const response = await fetch('https://localhost:44311/pay', {
//         method: 'POST',
//       });
//       const html = await response.json();
//       console.log(html.body)
//       const newWindow = window.open('', '_blank');
//       if (newWindow) {
//         newWindow.document.open();
//         newWindow.document.write(`
//           <!DOCTYPE html>
//           <html>
//           <head>
//           <meta charset="UTF-8">
//             <title>Alipay Payment</title>
//           </head>
//           <body>
//             ${html.body}
//           </body>
//           </html>
//         `);
//         newWindow.document.close();
//       }
//     } catch (error) {
//       console.error('Error fetching Alipay form:', error);
//     } finally {
//       setIsLoading(false);
//     }
//   }

//   return (
//     <div>
//       <button onClick={handleCreatOrderClick} className="h-10 w-20 bg-rose-300">
//         {isLoading ? '处理中...' : '下单'}
//       </button>
//       <div>
//         <h1>正在处理支付...</h1>
//         <div id="alipay-form-container"></div>
//       </div>
//     </div>
//   );
// }




'use client';
import { useState } from "react";

export default function Home() {
  const [isLoading, setIsLoading] = useState(false);

  const handleCreateOrderClick = async () => {
    setIsLoading(true);
    try {
      const response = await fetch('https://localhost:44311/pay', {
        method: 'GET',
      });
        const data = await response.json();
        const redirectUrl = data.body; 
        window.location.href = redirectUrl;
        console.log(data);
    } catch (error) {
      console.error('Error fetching Alipay form:', error);
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <div>
      <button onClick={handleCreateOrderClick} className="h-10 w-20 bg-rose-300">
        {isLoading ? '处理中...' : '下单'}
      </button>
      <div>
        <h1>正在处理支付...</h1>
        <div id="alipay-form-container"></div>
      </div>
    </div>
  );
}

