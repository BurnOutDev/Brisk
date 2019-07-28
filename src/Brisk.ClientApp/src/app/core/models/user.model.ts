export interface User {
    id: number;
    username: string;
    firstName: string;
    lastName: string;
    role: string;
    disabled: boolean;
    token?: string;
}