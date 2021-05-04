#version 430

uniform sampler2D tex;

//layout (location = 0) in vec4 gl_FragCoord
layout (location = 1) in vec4 v_color;
layout (location = 2) in vec2 v_uv;
layout (location = 3) in vec3 v_viewpos;

layout (location = 0) out vec4 frag_color;
layout (location = 1) out vec4 frag_coord;

uniform vec4 fog_color;
uniform float fog_near;
uniform float fog_far;

void main() {
    frag_color = texture(tex, v_uv) * v_color;
    
    // // TODO: I think this is awful for performance
    // if (frag_color.a == 0.0) {
    //     discard;
    // }

    //frag_color = vec4(0.0, 0.7, 1.0, 1.0);//1.0 - smoothstep(fog_near, fog_far, length(v_viewpos));
    frag_coord = gl_FragCoord;
}