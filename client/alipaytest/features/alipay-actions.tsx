// const response = await fetch('https://localhost:44311/pay', {
//     method: "POST",
//     headers: {
//       Accept: "application/json",
//       "Content-Type": "application/json;charset=UTF-8",
//     },
//   });
export async function postOrder(
): Promise<Response> {
    const response = await fetch('https://localhost:44311/pay', {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json;charset=UTF-8",
      },
    });
    return response.json()    
  }